import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { TaskList } from "./components/Pages/TaskList/TaskList";
import { About } from "./components/Pages/About/About";
import { Contacts } from "./components/Pages/Contacts/Contacts";

import './custom.css'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
export default class App extends Component {
   static displayName = App.name;

   render () {
      return (
         <Router basename={baseUrl}>
            <Layout>
               <Route exact path='/' component={Home} />
               <Route exact path='/tasks' component={TaskList} />
               <Route exact path='/about' component={About} />
               <Route exact path='/contacts' component={Contacts} />
            </Layout>
         </Router>
      );
   }
}
