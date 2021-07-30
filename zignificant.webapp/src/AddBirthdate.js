import React from 'react';

class AddBirthdates extends React.Component{
  state = {
    fullName: ''
  }

  changeHandler= evt => {
    const val = evt.target.value;
    console.log(val);
    this.setState({
      fullName: val
    });
  }

  render() {
    return (
      <div>
        <input 
          type='text'
          id='fullname' 
          onChange={this.changeHandler}
          value={this.state.fullName} />
      </div>
    )
  }
}

export default AddBirthdates;