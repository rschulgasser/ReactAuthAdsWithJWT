import React, { Component } from 'react';
import { Route } from 'react-router';
import { AuthContextComponent } from './AuthContext';
import Layout from './components/Layout';
import PrivateRoute from './components/PrivateRoute';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Signup from './Pages/Signup';
import Logout from './Pages/Logout';
import AddAd from './Pages/AddAd';
import myAccount from './Pages/MyAccount';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <AuthContextComponent>
        <Layout>
          <Route exact path='/' component={Home}/>
          <Route exact path='/signup' component={Signup} />
          <Route exact path='/login' component={Login} />
          <Route exact path='/logout' component={Logout} />
          <PrivateRoute exact path='/addad' component={AddAd}/>
          <PrivateRoute exact path='/myaccount' component={myAccount}/>

          
        </Layout>
      </AuthContextComponent>
    );
  }
}