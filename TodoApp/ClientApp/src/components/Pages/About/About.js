import React, { Component } from 'react';
import { Facebook } from "react-content-loader";
import { Row, Col } from "reactstrap";

export class About extends Component {

   render () {
      return (
         <Row>
            <Col>
               <div className="placeholders">
                  <Facebook className="code" />
                  <Facebook/>
               </div>
            </Col>
         </Row>
      );
   }
}
