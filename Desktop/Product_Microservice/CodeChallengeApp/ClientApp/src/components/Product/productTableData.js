import React from 'react';
import ReactDOM from 'react-dom';
import { Icon } from 'semantic-ui-react';


class productTableData extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            productData: null,
        };
    };

    render() {
        const { key, product } = this.props;
        return (
            < tr key={key}>
               
                <td>{product.name}</td>
                <td>{product.url}</td>
                <td>{product.code}</td>
                <td>
                    <Icon name="edit" product={product} onClick={() => this.props.selectProduct(product)} />
                    <Icon name="delete" product={product} onClick={() => this.props.deleteSelectProduct(product)} />
                </td>
            </tr >
        );
    }
}
export default productTableData;