import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router";
import axios from "axios";
import moment from "moment";

const EditBirthday2 = () => {
    let history = useHistory();
    let {id} = useParams();
    const [person, setPerson] = useState({
      id:-1,
      fullName: '',
      dob: null,
      dod: null,
      notoriety: ''
    });

    console.log('person', person);

    const handleChange = (e) => {
      let key = e.target.id;
      let val = e.target.value;
      console.log(key, val);
      setPerson({...person,[key]:val});
    }

    useEffect(() => {
      if(id!=='new') {
        axios.get(`https://localhost:44352/api/Birthdate/${id}`)
          .then(resp=>{
            console.log(resp.data);
            setPerson(resp.data);
          });
      }
    },[]);

    const handleClick = (e) => {
      if(id==='new'){
        axios.post('https://localhost:44352/api/Birthdate', person)
        .then(resp=>{
          console.log(resp);
          history.push("/");
        });
      } else {
        axios.put(`https://localhost:44352/api/Birthdate/${person.id}`, person)
        .then(resp=>{
          console.log(resp);
          history.push("/");
        });
      }
    }

    return(
      <div className= "container px-4">
        <div className="row g-3 needs-validation">
          <div className="col-md-12">
            <label htmlFor="validationCustom01" className="form-label">Full Name</label>
            <input type="text" 
                    className="form-control" 
                    id="fullName" 
                    value={person.fullName}
                    onChange={handleChange}
                    placeholder="Full Name" 
                    required 
                    />
            <div className="valid-feedback">
              Looks good!
            </div>
          </div>
          <div className="col-md-4">
            <label htmlFor="validationCustom03" className="form-label">Date Of Birth</label>
            <input type="date" 
                    className="form-control" 
                    id="dob" 
                    onChange={handleChange}
                    value={person.dob ? moment(person.dob).format("YYYY-MM-DD") : ''}
                    />
            <div className="invalid-feedback">
              Please provide a date of birth.
            </div>
          </div>
          <div className="col-md-4">
            <label htmlFor="validationCustom03" className="form-label">Date Of Death</label>
            <input type="date" 
                    className="form-control" 
                    id="dod" 
                    onChange={handleChange}
                    required 
                    value={person.dod ? moment(person.dod).format("YYYY-MM-DD") : ''}
                    />
            <div className="invalid-feedback">
              Please provide a date of death.
            </div>
          </div>
          <div className="col-md-4">
            <label htmlFor="validationCustom02" className="form-label">Notoriety</label>
            <input type="text" 
                    className="form-control" 
                    id="notoriety" 
                    onChange={handleChange}
                    placeholder="Description of Notoriety" 
                    required 
                    value={person.notoriety}/>
            <div className="valid-feedback">
              Looks good!
            </div>
          </div>
          <div className="col-12">
            <button 
              className="btn btn-primary" 
              onClick={handleClick}
              >Submit</button>
          </div>
        </div>
      </div>

    )
}

export default EditBirthday2;