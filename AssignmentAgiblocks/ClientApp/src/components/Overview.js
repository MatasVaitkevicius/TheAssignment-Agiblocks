import React, { Component, PropTypes } from 'react';
import './Overview.css';
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
        console.log(customer);
        this.setState({
            customers: customer
        });
    }

    render() {
        return (
            <div>
                <table>
                    <thead>
                        <tr>

                            <th>CustomerID</th>
                            <th>CounterPartID</th>
                            <th>Company Name</th>
                            <th>Is Buyer</th>
                            <th>Is Seller</th>
                            <th>Phone</th>
                            <th>Fax</th>

                        </tr>
                    </thead>
                    <tbody>
                        {this.state.customers.length > 0 && this.state.customers.map((d, i) => (
                            <tr key={i}>
                                <React.Fragment>
                                    <td>{d.customerId}</td>
                                    <td>{d.counterPartID}</td>
                                    <td>{d.companyName}</td>
                                    <td>{d.isBuyer}</td>
                                    <td>{d.isSeller}</td>
                                    <td>{d.phone}</td>
                                    <td>{d.fax}</td>
                                </React.Fragment>
                            </tr>
                        ))}
                    </tbody>

                </table>
            </div>
        )
    }
}

