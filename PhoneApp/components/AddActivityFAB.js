import React from 'react';
import {FAB} from 'react-native-paper';

const AddActivityFAB = ({setDialogVisible}) => {
  return (
    <FAB
      style={{position: 'absolute', margin: 20, padding: 10 ,right: 0, bottom: 0, backgroundColor: '#FF8C00'}}
      small
      icon="plus"
      onPress={() => setDialogVisible(true)}
    />
  );
};

export default AddActivityFAB;
