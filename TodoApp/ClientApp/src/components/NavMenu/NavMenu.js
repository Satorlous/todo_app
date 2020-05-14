import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import logo from '../../media/logo.png';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="nav navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3">
          <Container>
            <NavbarBrand tag={Link} to="/"><img className="logo" src={logo} alt="Logo"/></NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} to="/tasks">Задачи</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} to="/contacts">Обратная связь</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} to="/about">О нас</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} to="/signin">Вход</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} to="/signup">Регистрация</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
