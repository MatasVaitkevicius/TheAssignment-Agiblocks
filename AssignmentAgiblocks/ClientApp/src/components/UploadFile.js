import React, { Component, PropTypes } from 'react';
import CustomerService from '../Services/CustomerService';

export class UploadFile extends Component {

    constructor(props) {
        super(props);
        this.state = {
            file: null,
        }
        this.onSubmitClick = this.onSubmitClick.bind(this);
    }

    onSubmitClick() {
        CustomerService().uploadCustomersData(this.state.file);
    }

    render() {
        return (
            < div >
                <input type="file" accept=".csv" onChange={(e) => this.setState({ file: e.nativeEvent.target.files[0] })} />
                {
                    this.state.file && (<button onClick={() => this.onSubmitClick()}>Upload</button>)
                }
               
            </div>
        )
    }
}

