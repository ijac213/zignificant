import React from 'react';

class AddHistory extends React.Component{
  state = {
    fullname:''
  }

  changeHandler = evt => {
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
        type = 'text'
        id='date'
        onChange={this.changeHandler}
        value={this.state.date} />
      </div>
    )
  }
}

export default AddHistory; 