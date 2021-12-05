import React, {useState} from 'react';
import {List, Colors} from 'react-native-paper';
import {View} from 'react-native';

const RepairStateIcon = ({state}) => {
  let iconStyle;
  if (state === 0) {
    iconStyle = {
      color: Colors.green500,
      icon: 'checkbox-marked-circle',
    };
  } else if (state === 1) {
    iconStyle = {
      color: Colors.blue500,
      icon: 'autorenew',
    };
  } else if (state === 2) {
    iconStyle = {
      color: Colors.grey500,
      icon: 'circle-outline',
    };
  }
  return (
    <List.Icon
      {...iconStyle}
      onPress={() => {
        setDialogVisible(true);
      }}
    />
  );
};

export default RepairStateIcon;
