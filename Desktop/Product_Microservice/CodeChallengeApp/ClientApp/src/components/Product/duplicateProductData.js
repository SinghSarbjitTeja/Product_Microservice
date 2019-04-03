import React from 'react';
import ReactDOM from 'react-dom';
import { Icon } from 'semantic-ui-react';
import DuplicateTableData from './duplicateTableData.js';

class DuplicateProductData extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            productData: null,
        };
    };

    render() {
        const { product } = this.props;
        
        let display = '';
        let dispArray = [];
        let nameArray = [];
        Object.entries(product).forEach(([key, value]) => {
            if (value > 1) {
                let productName = key.slice(1, key.length - 1);
                let object = {
                    [productName]: `${productName} (${value})`
                }
                dispArray.push(object);
            }
        });

        return (
            dispArray.map(data => (
                <DuplicateTableData key={Object.keys(data)[0]} data={data} findProduct={this.props.findProduct} deleteSelectProduct={this.props.deleteSelectProduct} />
            )));
    }
}

export default DuplicateProductData; 