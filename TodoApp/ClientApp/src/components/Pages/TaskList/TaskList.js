import React from 'react';
import {Card, CardBody, CardSubtitle, CardText, CardTitle, Col, Row, Spinner} from 'reactstrap';
import styles from './TaskList.module.css';
import cx from 'classnames';

export class TaskList extends React.Component {
   static displayName = TaskList.name;

   constructor(props) {
      super(props);
      this.state = {
         tasks: [],
         loading: true
      };
   }

   componentDidMount() {
      this.populateTasksData();
   }

   static renderList(tasks) {

      const convertDate = (d) => {
         let date = new Date(d);
         return `${("0" + date.getDate()).slice(-2)}.${("0" + (date.getMonth() + 1)).slice(-2)}.${date.getFullYear()}, ${date.getHours()}:${date.getMinutes()}`;
      }

      return (
         tasks.map(t =>
            {
               return (
                  <Col md={12} key={t.id}>
                     <div className={styles.task}>
                        <Card className={cx(
                           styles.card,
                           t.importanceId === 1 ? styles.low :
                              t.importanceId === 2 ? styles.belowMid :
                                 t.importanceId === 3 ? styles.mid :
                                    t.importanceId === 4 ? styles.belowHigh :
                                       styles.high
                        )}>
                           <CardBody>
                              <CardTitle><b>Заголовок:</b> {t.header}</CardTitle>
                              <CardSubtitle><b>Дата/время выдачи:</b> {convertDate(t.createdAt)}</CardSubtitle>
                              <CardText><b>Описание:</b> {t.description}</CardText>
                           </CardBody>
                        </Card>
                     </div>
                  </Col>
               );
            }

         )
      );
   }

   render() {
      let taskList = this.state.loading ? <Spinner/> : TaskList.renderList(this.state.tasks);

      return (
         <Row className={styles.body}>
            <Col>
               <span className={styles.header}>Мои задачи</span>
               <Row className={styles.tasksContainer}>{taskList}</Row>
            </Col>
         </Row>
      );
   }

   async populateTasksData() {
      await fetch('todo/tasks').then(async (response) => {
         const data = await response.json();
         this.setState({ tasks: data, loading: false });
         console.log(this.state.tasks);
      });
   }
}
