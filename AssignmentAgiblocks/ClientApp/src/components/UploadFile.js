import React, { Component, PropTypes } from 'react';

export class UploadFile extends Component {

    constructor(props) {
        super(props);
        this.state = {
            file: null,
        }
        this.onSubmitClick = this.onSubmitClick.bind(this);
    }

    onSubmitClick() {
        const fd = new FormData()
        fd.append('file', this.state.file)

        fetch("https://localhost:5001/api/customer/Upload", {
            method: 'POST',
            body: fd,
        })
    }

    render() {
        return (
            < div >
                <input type="file" onChange={(e) => this.setState({ file: e.nativeEvent.target.files[0] })}/>
            <button onClick={()=> this.onSubmitClick()}>Upload</button>
            </div>
        )
    }
}

