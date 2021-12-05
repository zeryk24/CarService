// Author: Michal Zavadil (xzavad18)
import React from 'react';
import {Header} from 'react-native-elements';

const AppHeader = () => {
  return (
    <Header
      leftComponent={{
        icon: 'menu',
        color: '#fff',
        iconStyle: {color: '#fff'},
      }}
      centerComponent={{text: 'MY TITLE', style: {color: '#fff'}}}
      rightComponent={{icon: 'home', color: '#fff'}}
    />
  );
};

export default AppHeader;
