import React, {useState} from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import EditBirthday from './EditBirthday';
import './App.css';
import BirthdateList from './BirthdateList';
import EditBirthday2 from './EditBirthdays2';

function App() {
    const [isNavCollapsed,setIsNavCollapsed] = useState(true);
    const handleNavCollapsed = () => setIsNavCollapsed(!isNavCollapsed);
  return (
    <div className="App">
      <header className="App-header">
        Zignificant 
      </header>
      <Router>
      <div>
      
{/*Start*/}
<nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
        <Link to='/' className="navbar-brand">Zignificant</Link>
        <button 
          className="navbar-toggler" 
          type="button" 
          data-bs-toggle="collapse" 
          data-bs-target="#navbarSupportedContent" 
          aria-controls="navbarSupportedContent" 
          aria-expanded={!isNavCollapsed ? true : false } 
          aria-label="Toggle navigation"
          onClick={handleNavCollapsed}>
          <span className="navbar-toggler-icon"></span>
        </button>
          <div className={`${isNavCollapsed ? 'collapse' : ''}  navbar-collapse`} id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link className="nav-link active" to="/">List</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link active" to="/edit/new">Add</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
{/*End*/}

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/edit/:id">
            <EditBirthday2 />
          </Route>
          <Route path="/edit/new">
            <EditBirthday2 />
          </Route>
          <Route path="/">
            <BirthdateList />
          </Route>
        </Switch>
      </div>
    </Router>
    </div>
  );
}

export default App; 
