import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Product from './components/Product/Product';
import DuplicateProduct from './components/Product/DuplicateProduct';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>      
            <Route exact path='/' component={Product} />
            <Route exact path='/duplicate' component={DuplicateProduct} />
      </Layout>
    );
  }
}
//<Route exact path='/' component={Home} />
