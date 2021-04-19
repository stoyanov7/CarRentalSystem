import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Navigation from './components/Navigation';

import Home from './pages/Home';
import Login from './pages/Login';
import Cars from './pages/Cars';

import 'bootstrap/dist/css/bootstrap.min.css';

export default function App() {
  return (
    <div className="App">
      <Router>
        <Navigation />
        <div className="container">
          <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/cars' component={Cars} />
            <Route exact path='/login' component={Login} />
          </Switch>
        </div>
      </Router>
      
    </div>
    
  );
}
