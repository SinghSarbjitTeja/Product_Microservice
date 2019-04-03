import React from 'react';
import axios from 'axios';
import ProductData from './productData.js';
import Edit from './edit.js';
import { Button } from 'semantic-ui-react'

class Product extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            productList: [],
            showModal: false,
            selectedProduct: ""
        };
        this.selectProduct = this.selectProduct.bind(this);
        this.deleteSelectProduct = this.deleteSelectProduct.bind(this);
        this.saveProduct = this.saveProduct.bind(this);
        this.closeModal = this.closeModal.bind(this);
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
                })
            })
            .catch(error => {
                console.log(error.response)
            });
    }
    closeModal() {
        this.setState({
            showModal: false
        });
    }

    selectProduct(product) {
        debugger;
        this.setState({
            selectedProduct: product,
            showModal: true
        });
    }

    addNew() {
        this.setState({
            selectedProduct: {},
            showModal: true,
        });
    }

    deleteSelectProduct(product) {
        axios({
            method: 'delete',
            url: 'http://localhost:52077/api/product/' + product.id,
        })
            .then(function (res) {
                debugger;
                alert(res.data.message);
              //  this.reload();
                window.location.reload(true);
            })
            .catch(error => {
                console.log(error.response)
            });
    }

    saveProduct(productTobeSaved) {
        debugger;
        let self = this;
        if (productTobeSaved.id === undefined || productTobeSaved.id === null) {
            axios({
                method: 'post',
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
        }
        else {
            axios({
                method: 'put',
                url: 'http://localhost:52077/api/product',
                data: productTobeSaved,
            })
                .then(function (res) {
                    alert(res.data.message);

                })
                .catch(error => {
                    console.log(error.response)
                });
        }
        this.setState({
            showModal: false
        });
    }

    render() {
        return (
            <div >
                {this.state.selectedProduct && <Edit selectProduct={this.selectProduct}
                    selectedProduct={this.state.selectedProduct}
                    closeModal={this.closeModal} showModal={this.state.showModal}
                    saveProduct={this.saveProduct} listOfProducts={this.state.productList} />
                }
                <Button color='blue' onClick={() => this.addNew()}>Create New Product</Button>
                <ProductData productData={this.state.productList} selectProduct={this.selectProduct}
                    deleteSelectProduct={this.deleteSelectProduct} />
            </div>
        );
    }
}
export default Product;






