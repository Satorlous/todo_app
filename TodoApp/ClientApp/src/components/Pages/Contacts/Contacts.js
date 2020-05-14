import React, { Component } from 'react';
import { Code, Facebook } from "react-content-loader";
import { Row, Col } from "reactstrap";

export class Contacts extends Component {

   render () {
      return (
         <Row>
            <Col>
               <div className="placeholders">
                  <Code className="code" />

                  <Facebook/>
               </div>
            </Col>
         </Row>
      );
   }
}
