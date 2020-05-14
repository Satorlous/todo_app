import React, {Component} from "react"
import ContentLoader from "react-content-loader"
import * as RT from 'reactstrap'
import Col from "reactstrap/es/Col";

class ContentPlaceholder extends Component{
   render() {
      return (
         <RT.Row>
            <Col lg={6} md={12} className="pr-3">
               <ContentLoader
                  title={""}
                  speed={5}
                  width={500}
                  height={400}
                  backgroundColor="#f3f3f3"
                  foregroundColor="#ecebeb"
               >
                  <rect x="5" y="15" rx="5" ry="5" width="460" height="10" />
                  <rect x="5" y="35" rx="5" ry="5" width="400" height="10" />
                  <rect x="5" y="55" rx="5" ry="5" width="480" height="10" />
                  <rect x="5" y="75" rx="5" ry="5" width="450" height="10" />
                  <rect x="5" y="105" rx="10" ry="10" width="480" height="200" />
               </ContentLoader>
            </Col>
            <Col lg={6} md={12}>
               <ContentLoader
                  title={""}
                  speed={5}
                  width={500}
                  height={400}
                  backgroundColor="#f3f3f3"
                  foregroundColor="#ecebeb"
               >
                  <rect x="5" y="15" rx="5" ry="5" width="460" height="10" />
                  <rect x="5" y="35" rx="5" ry="5" width="400" height="10" />
                  <rect x="5" y="55" rx="5" ry="5" width="480" height="10" />
                  <rect x="5" y="75" rx="5" ry="5" width="450" height="10" />
                  <rect x="5" y="105" rx="10" ry="10" width="480" height="200" />
               </ContentLoader>
            </Col>
         </RT.Row>

      );
   }
}


export default ContentPlaceholder