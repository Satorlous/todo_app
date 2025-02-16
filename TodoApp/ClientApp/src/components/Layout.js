import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu/NavMenu';
import { Footer } from './Footer/Footer';

export class Layout extends Component {
   static displayName = Layout.name;

   render () {
      return (
         <>
            <NavMenu />
            <Container>
               {this.props.children}
            </Container>
            <Footer/>
         </>
      );
   }
}
