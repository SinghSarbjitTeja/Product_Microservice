import React from 'react';
import ReactDOM from 'react-dom';
import { Icon } from 'semantic-ui-react';


class DuplicateTableData extends React.Component {
    constructor(props) {
        super(props);
    };
    render() {
        const { data } = this.props;
        let productNum = Object.keys(data)[0];
        let displayValue = data[Object.keys(data)[0]];
        debugger;
        return (
            <tr key={productNum}>
                <td>{displayValue}</td>
                <td>
                    <Icon name="edit" onClick={() => this.props.findProduct(productNum)} />
                    <Icon name="delete" onClick={() => this.props.deleteSelectProduct(productNum)} />
                </td>
            </tr>
        );
    }
}
export default DuplicateTableData;