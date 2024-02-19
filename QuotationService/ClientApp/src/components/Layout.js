import React, { Component } from 'react';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (

          <div className='container customcontainer card shadow p-2'>
            <NavMenu/>
            <div className='card-body p-4'>
              {this.props.children}
            </div>
          </div>
    );
  }
}
