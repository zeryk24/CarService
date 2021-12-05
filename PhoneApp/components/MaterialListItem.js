import React from 'react';
import {Text, View} from 'react-native';
import {List} from 'react-native-paper';

const MaterialListItem = ({title, amount}) => {
  return (
    <View>
      <List.Item
        key={index}
        title={title}
        right={() => <Text>{amount}</Text>}
      />
    </View>
  );
};

export default MaterialListItem;
