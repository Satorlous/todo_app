import React, { Component } from 'react';
import './Footer.css';
import { Container } from "reactstrap/es";
import { Col,Row } from "reactstrap";

export class Footer extends Component {
   render() {
      return (
         <footer>
            <Container fluid>
               <Row className="contacts">
                  <Col md={{size: 4, offset: 4}} className="copyright">
                     <span className="copyright">Copyright (C) 2020</span>
                  </Col>
                  <Col>
                     <span className="mail">Почта: n.leppik@gmail.com</span>
                     <span className="phone">Телефон: 8-982-916-26-13</span>
                  </Col>
               </Row>
            </Container>
         </footer>
      );
   }
}
