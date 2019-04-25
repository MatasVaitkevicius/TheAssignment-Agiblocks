import React, { Component } from 'react';
import CustomerService from '../Services/CustomerService';
import './UploadFile.css';
import { Link } from 'react-router-dom'

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
                <h6>1.Select a csv format file</h6>
                < input type="file" accept=".csv" onChange={(e) => this.setState({ file: e.nativeEvent.target.files[0] })} />
                {
                    this.state.file && (<div> <br/>
                        <h6>2.Press button Upload to upload your csv file</h6>
                        <button className="upload-file-button" onClick={() => this.onSubmitClick()}>Upload</button>
                        <br />
                        <br />
                        <h6>3.You can check your all your data imported from csv(s) listed in the <Link to="/overview">Overview</Link></h6>
                    </div>)
                }
            </div>
        )
    }
}

