import React, { Component } from 'react';
import { Link } from 'react-router-dom'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h3>The Assignment</h3>
            <br/>
            <h5>Welcome to my MVC web application with the following features:</h5>
            <ul>
                <li><Link to="/upload-file">Upload file</Link> - Import the csv file using the web interface.</li>
                <li><Link to="/overview">Overview</Link> - an Overview page with all the counter party from the imported csv(s) listed.</li>
            </ul>
      </div>
    );
  }
}
