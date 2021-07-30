import React, { Component } from 'react';
import axios from 'axios';
import {withRouter} from 'react-router';

class EditBirthday extends Component {
  state = {
    id:-1,
    fullName: '',
    dob: '',
    dod: null,
    notoriety: ''
  };

  handleChange = (e) => {
    const key = e.target.id;
    const val = e.target.value;
    console.log(key,val);
    this.setState({
      [key]:val
    });
  }

  handleClick = (e) => {
    console.log(this.state);
    axios.post('https://localhost:44352/api/Birthdate', this.state)
      .then(res=> {
        console.log('handleClick', res)
      })
  }

  componentDidMount() {
   // const id = this.props.match.params.id;
    console.log(this.props);
  }

  render() {
    return (
      <div className= "container px-4">
        <div className="row g-3 needs-validation">
          <div className="col-md-12">
            <label for="validationCustom01" className="form-label">Full Name</label>
            <input type="text" 
                    className="form-control" 
                    id="fullName" 
                    value={this.state.fullName}
                    placeholder="Full Name" 
                    required 
                    onChange={this.handleChange}/>
            <div className="valid-feedback">
              Looks good!
            </div>
          </div>
          <div className="col-md-4">
            <label for="validationCustom03" className="form-label">Date Of Birth</label>
            <input type="date" 
                    className="form-control" 
                    id="dob" 
                    required 
                    value={this.state.dob}
                    onChange={this.handleChange}/>
            <div className="invalid-feedback">
              Please provide a date of birth.
            </div>
          </div>
          <div className="col-md-4">
            <label for="validationCustom03" className="form-label">Date Of Death</label>
            <input type="date" 
                    className="form-control" 
                    id="dod" 
                    required 
                    value={this.state.dod}
                    onChange={this.handleChange}/>
            <div className="invalid-feedback">
              Please provide a date of death.
            </div>
          </div>
          <div className="col-md-4">
            <label for="validationCustom02" className="form-label">Notoriety</label>
            <input type="text" 
                    className="form-control" 
                    id="notoriety" 
                    placeholder="Description of Notoriety" 
                    required 
                    value={this.state.notoriety}
                    onChange={this.handleChange}/>
            <div className="valid-feedback">
              Looks good!
            </div>
          </div>
          <div className="col-12">
            <button 
              className="btn btn-primary" 
              onClick={this.handleClick}>Submit</button>
          </div>
        </div>
      </div>
    )
  }
}

export default EditBirthday;