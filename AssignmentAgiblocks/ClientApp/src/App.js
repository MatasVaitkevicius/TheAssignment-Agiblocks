import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { UploadFile } from './components/UploadFile';
import { Overview } from './components/Overview';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/upload-file' component={UploadFile} />
                <Route path='/overview' component={Overview} />
            </Layout>
        );
    }
}
