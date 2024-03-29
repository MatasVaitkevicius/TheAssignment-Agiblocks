﻿import React, { Component, PropTypes } from 'react';
import CustomerService from '../Services/CustomerService';

export class Overview extends Component {

    constructor(props) {
        super(props);
        this.state = {
            customers: []
        };
    }

    async componentDidMount() {
        const customer = await CustomerService().getCustomersData();
        this.setState({
            customers: customer
        });
    }

    async onDeleteCustomer(customerId) {
        await CustomerService().deleteCustomerData(customerId);
        const customer = await CustomerService().getCustomersData();
        this.setState({
            customers: customer
        });
    }

    render() {
        return (
            <div>
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>CustomerID</th>
                            <th>CounterPartID</th>
                            <th>Company Name</th>
                            <th>Is Buyer</th>
                            <th>Is Seller</th>
                            <th>Phone</th>
                            <th>Fax</th>
                            <th>Remove Customer</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.customers.length > 0 && this.state.customers.map((d, i) => (
                            <tr key={i}>
                                <React.Fragment>
                                    <td>{d.customerId}</td>
                                    <td>{d.counterPartId}</td>
                                    <td>{d.companyName}</td>
                                    <td>{d.isBuyer}</td>
                                    <td>{d.isSeller}</td>
                                    <td>{d.phone}</td>
                                    <td>{d.fax}</td>
                                    <td><button className="btn btn-warning btn-sm" onClick={() => this.onDeleteCustomer(d.customerId)}>Remove Customer</button></td>
                                </React.Fragment>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        )
    }
}

