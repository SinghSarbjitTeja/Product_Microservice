import React from 'react';
import { Button, Header, Modal, Form, Input } from 'semantic-ui-react';
import Joi from 'joi-browser';

const style = {
    top: 20 + '%',
    bottom: 'auto',
    position: 'absolute',
    zIndex: 9000,
    left: 30 + '%',
}

class Edit extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            errors: {}
        }
        this.handleInputChange = this.handleInputChange.bind(this);
        this.saveProductCheck = this.saveProductCheck.bind(this);
    };

    schema = {
        name: Joi.string().required().label('Name'),
        url: Joi.string().required().regex(/((([A-Za-z]{3,9}:(?:\/\/)?)(?:[\-;:&=\+\$,\w]+@)?[A-Za-z0-9\.\-]+|(?:www\.|[\-;:&=\+\$,\w]+@)[A-Za-z0-9\.\-]+)((?:\/[\+~%\/\.\w\-_]*)?\??(?:[\-\+=&;%@\.\w_]*)#?(?:[\.\!\/\\\w]*))?)/).error(errors => {
            return {
                message: "Url is wrong format"
            };
        }).label('Url'),
        code: Joi.number().required().label('Code')
    }

    handleInputChange(event) {
        let { name, value } = event.target;
        this.setState({ errors: {} });
        if (name == 'name') {
            this.props.selectedProduct.name = value;
        }
        else if (name == 'url') {
            this.props.selectedProduct.url = value;
        }
        else {
            this.props.selectedProduct.code = value;
        }
        this.props.selectProduct(this.props.selectedProduct);
    }

    saveProductCheck(selectedProduct) {
        const obj = {
            "name": selectedProduct.name,
            "url": selectedProduct.url,
            "code": selectedProduct.code
        };
        const { error } = Joi.validate(obj, this.schema, { abortEarly: false });
        const errors = {};
        //     console.log(error.details)
        debugger;
        let duplicate = this.props.listOfProducts.filter(x => x.url === selectedProduct.url || x.code === selectedProduct.code);
        console.log(duplicate);
        if (duplicate.length !== 0 && duplicate[0].id !== selectedProduct.id) {
            
            errors.duplicate = "url/code already exist";
            this.setState({ errors })
            return null;
        }
        if (error == null) {
            this.props.saveProduct(selectedProduct);
            return null
        };
        for (let item of error.details) {
            errors[item.path[0]] = `${item.message}`;
        }
        this.setState({ errors })
        return this.state.errors;

    }

    render() {
        const { selectedProduct } = this.props;

        return (
            <div className="overlay">
                <Modal size={'tiny'} open={this.props.showModal} style={style}>
                    <Modal.Header>Product</Modal.Header>
                    <Modal.Content >
                        <Form>
                            {this.state.errors['duplicate'] ? (<div className="ui pointing red basic label">{this.state.errors['duplicate']}</div>) : null}
                            <Form.Field>
                                <label>Product Name</label>
                                <Input id="name" placeholder="Please enter product name..." name="name" required value={selectedProduct.name} id="name" onChange={(event) => this.handleInputChange(event)} />
                                {this.state.errors['name'] ? (<div className="ui pointing red basic label">{this.state.errors['name']}</div>) : null}
                            </Form.Field>

                            <Form.Field>
                                <label>Product Url</label>
                                <Input id="url" placeholder=" Please enter product url..." name="url" required value={selectedProduct.url} id="price" onChange={(event) => this.handleInputChange(event)} />
                                {this.state.errors['url'] ? (<div className="ui pointing red basic label">{this.state.errors['url']}</div>) : null}
                            </Form.Field>

                            <Form.Field>
                                <label>Product Code</label>
                                <Input id="code" placeholder=" Please enter product code numeric.."
                                    name="code"
                                    required value={selectedProduct.code}
                                    id="name"
                                    onChange={(event) => this.handleInputChange(event)}
                                />
                                {this.state.errors['code'] ? (<div className="ui pointing red basic label">{this.state.errors['code']}</div>) : null}
                            </Form.Field>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='grey' onClick={() => this.props.closeModal()} >Cancel</Button>
                        <Button color='blue' onClick={() => this.saveProductCheck(selectedProduct)}>Save</Button>
                    </Modal.Actions>
                </Modal>
            </div>
        );
    }
}
export default Edit;

