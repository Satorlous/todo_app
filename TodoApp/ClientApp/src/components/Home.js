import React, { Component } from 'react';
import ContentPlaceholder from "./ContetPlaceholder/ContentPlaceholder";
import { Row, Col } from "reactstrap";

export class Home extends Component {

   render () {
      return (
         <Row>
            <Col>
               <div className="placeholders">
                  <ContentPlaceholder/>
                  <ContentPlaceholder/>
               </div>
            </Col>
         </Row>
      );
   }
}
