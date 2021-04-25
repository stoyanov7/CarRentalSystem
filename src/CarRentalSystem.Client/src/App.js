import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './redux/store';
import axios from 'axios';
import jwtDecode from 'jwt-decode';
import { logoutUser } from './redux/actions/userActions';

import Navigation from './components/Navigation';

import Home from './pages/Home';
import Login from './pages/Login';
import Cars from './pages/Cars';
import Signup from './pages/Signup';

import 'bootstrap/dist/css/bootstrap.min.css';

const token = localStorage.token;

if (token) {
  const decodedToken = jwtDecode(token);
  
  if (decodedToken.exp * 1000 < Date.now()) {
    store.dispatch(logoutUser())
    window.location.href = '/login';
  } else {
    store.dispatch({ type: 'SET_AUTHENTICATED' });
    axios.defaults.headers.common['Authorization'] = token;    
  }
}

export default function App() {
  return (
    <div className="App">
      <Provider store={store}>    
        <Router>
          <Navigation />        
            <Switch>
              <Route exact path='/' component={Home} />
              <Route exact path='/cars' component={Cars} />
              <Route exact path='/login' component={Login} />
              <Route exact path='/signup' component={Signup} />
            </Switch>        
        </Router>   
      </Provider>   
    </div>    
  );
}
