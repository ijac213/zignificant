import React from 'react';
import axios from 'axios';
import Moment from 'react-moment';
import 'bootstrap/dist/css/bootstrap/css';
import './HistoryList.module.css';
import { Link } from 'react-router-dom';
import Swal from 'sweetalert2';


class HistoryList extends React.Component {
  state = {
    history: []
  }

  handleClick=id=>{
    console.log(id)
    Swal.fire({
      title: 'Are You Sure?',
      text: "You Won't Be Able To Revert This!",
      icon: 'warning',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    })
    .then(result => {
      if (result.isConfirmed) {
         axios.delete(`https://localhost:44352/api/History/${id}`)
            .then(resp=>{
                Swal.fire(
                  'Deleted!',
                  'The record has been deleted.',
                  'success'
                );
            this.loadData();
          })
     }
    });

  }

  loadData=()=>{
    axios.get('https://localhost:44352/api/History')
    .then(res=> {
      console.log('componentDidMount', res)
      this.setState({
        history: [...res.data]
      })
    });
  }


  componentDidMount(){
    this.loadData();
  }
  
  render(){
    console.log('renderFunction',this.state.history)

    return(
      <div className="ztable">
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th>Action</th>
              <th>Date</th>
              <th>Title</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            {
              this.state.history.map((elem,idx)=>{
                return(
                  <tr key={idx}>
                    <td>
                    <Link className="btn btn-outline-primary btn-sm" to={`/edit/${elem.id}`}>edit</Link> <button className="btn btn-outline-danger btn-sm" onClick={(e)=>this.handleClick(elem.id)}>delete</button>
                    </td>
                    <td><Moment format="MM/DD/YYYY">{elem.date}</Moment></td>
                    <td>{elem.title}</td>
                    <td>{elem.description}</td>
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

export default HistoryList;