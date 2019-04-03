import React from 'react';
import axios from 'axios';
import ProductData from './productData.js';
import DuplicateProductData from './duplicateProductData.js';
import Edit from './edit.js';
import './product.css';
import { Button } from 'semantic-ui-react';

export default class DuplicateProduct extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            productList: [],
            showModal: false,
            selectedProduct: "",
            numberOfValues: {},
            showModal: false,
        };
        this.findDuplicate = this.findDuplicate.bind(this);
        this.selectProduct = this.selectProduct.bind(this);
        this.findProduct = this.findProduct.bind(this);
        this.closeModal = this.closeModal.bind(this);
        this.saveProduct = this.saveProduct.bind(this);
        this.deleteSelectProduct = this.deleteSelectProduct.bind(this);
        this.reload = this.reload.bind(this);
    }
    componentDidMount() {
        this.reload();
    }

    reload() {
        let self = this;
        axios({
            method: 'get',
            url: 'http://localhost:52077/api/product',
        })
            .then(function (res) {
                let data = res.data;   
                self.setState({
                    productList: data
                }, () => {
                    self.findDuplicate(self.state.productList);
                })
            })
            .catch(error => {
                console.log(error.response)
            });
    }

    findDuplicate(values) {
        debugger;
        if (values == undefined || "") { values = this.state.productList };
        var k = values.map((obj) => {
            return obj.name
        })
        var counter = {}
        k.forEach(obj => {
            var key = JSON.stringify(obj)
            counter[key] = (counter[key] || 0) + 1
        });
        this.setState({
            numberOfValues: counter
        })
    }

    findProduct(productName) {
        debugger;
        var result = this.state.productList.find(obj => obj.name === productName);
        this.setState({
            selectedProduct: result,
            showModal: true
        })
    }

    closeModal() {
        this.setState({
            showModal: false
        })
    }

    saveProduct(productTobeSaved) {
        let self = this;
        axios({
            method: 'put',
            url: 'http://localhost:52077/api/product',
            data: productTobeSaved,
        })
            .then(function (res) {
                alert(res.data.message);
                window.location.reload(true);
            })
            .catch(error => {
                console.log(error.response)
            });

        self.setState({
            showModal: false
        }, () => { console.log(this.state.showModal) });
    }

    selectProduct(product) {
        this.setState({
            selectedProduct: product,
            showModal: true
        });
    }

    deleteSelectProduct(productTobeDeleted) {
        debugger;
        let result = this.state.productList.find(obj => obj.name === productTobeDeleted);
        axios({
            method: 'delete',
            url: 'http://localhost:52077/api/product/' + result.id,
        })
            .then(function (res) {
                alert(res.data.message);
                window.location.reload(true);
            })
            .catch(error => {
                console.log(error.response)
            });

    }

    render() {
        console.log(this.state.selectedProduct);
        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Product Name and Occurance</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody >
                        <DuplicateProductData product={this.state.numberOfValues} findProduct={this.findProduct} deleteSelectProduct={this.deleteSelectProduct} />
                    </tbody>
                </table>
                {
                    this.state.selectedProduct && <Edit selectProduct={this.selectProduct} selectedProduct={this.state.selectedProduct}
                        listOfProducts={this.state.productList} deleteSelectProduct={this.deleteSelectProduct} saveProduct={this.saveProduct} closeModal={this.closeModal} showModal={this.state.showModal} />
                }
            </div>
        );
    }
};