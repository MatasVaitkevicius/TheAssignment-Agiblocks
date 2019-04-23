import React, { Component, PropTypes } from 'react';
import './Overview.css';

export class Overview extends Component {

    constructor(props) {
        super(props);
        this.state = {
            customers: []
        };
    }

    componentDidMount() {
        fetch('https://localhost:5001/api/customer')
            .then(data => data.json())
            .then((data) => {
                console.log(data)

                this.setState({ customers: data })
            });

    }

    render() {
        console.log(this.state.customers)
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
                        {this.state.customers.length > 0 && this.state.customers.map((d) => (
                            <tr>
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

