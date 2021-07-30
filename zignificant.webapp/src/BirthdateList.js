import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
import 'bootstrap/dist/css/bootstrap.css';
import './BirthdateList.module.css';
import { Link } from 'react-router-dom';


class BirthdateList extends React.Component {
  state = {
    birthdates: []
  }

  handleClick=id=>{
    console.log(id)
    axios.delete(`https://localhost:44352/api/Birthdate/${id}`)
      .then(resp=>{
        this.loadData();
      })
  }

  loadData=()=>{
    axios.get('https://localhost:44352/api/Birthdate')
      .then(res=> {
        console.log('componentDidMount', res)
        this.setState({
          birthdates: [...res.data]
        })
      });
  }

  componentDidMount(){
    this.loadData();
  }

  render(){
    console.log('renderFunction',this.state.birthdates)

    return(
      <div className="ztable">
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th>Action</th>
              <th>Full Name</th>
              <th>Dob</th>
              <th>Dod</th>
              <th>Notoriety</th>
            </tr>
          </thead>
          <tbody>
            {
              this.state.birthdates.map((elem, idx)=>{
                return(
                  <tr key={idx}>
                    <td>
                      <Link className="btn btn-outline-primary btn-sm" to={`/edit/${elem.id}`}>edit</Link> <button className="btn btn-outline-danger btn-sm" onClick={(e)=>this.handleClick(elem.id)}>delete</button>
                    </td>
                    <td>{elem.fullName}</td>
                    <td><Moment format="MM/DD/YYYY">{elem.dob}</Moment></td>
                    <td>{elem.dod ? <Moment format="MM/DD/YYYY">{elem.dod}</Moment> : null}</td>
                    <td>{elem.notoriety}</td>
                  </tr>
                )
              })
            }
          </tbody>
        </table>
    </div>
    )
  }
}

export default BirthdateList;