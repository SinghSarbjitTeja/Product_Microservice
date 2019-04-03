import React from 'react';
import ReactDOM from 'react-dom';
import  './product.css';
import ProductTableData from './productTableData.js';

class productData extends React.Component {
    constructor(props) {
        super(props);
    };

    render() {
        const productData = this.props.productData;
        return (
            <table>
                <thead>
                    <tr>
                        
                        <th>Product Name</th>
                        <th>Product URL</th>
                        <th>Product Code</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody >
                    {
                        productData.map(product => (
                            <ProductTableData key={product.Id} product={product} selectProduct={this.props.selectProduct} deleteSelectProduct={this.props.deleteSelectProduct} />

                        ))}
                </tbody>
            </table>
        );
    }
}
export default productData;