import React, {useState, useContext} from 'react';
import {List, Colors, IconButton} from 'react-native-paper';
import {View} from 'react-native';
import {DialogContext} from './ActivityAccordion';

const ActivityStateIcon = ({state}) => {
  const {dialogVisible, setDialogVisible} = useContext(DialogContext);
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
    <IconButton
      {...iconStyle}
      onPress={() => {
        setDialogVisible(true);
      }}
    />
  );
};

export default ActivityStateIcon;
