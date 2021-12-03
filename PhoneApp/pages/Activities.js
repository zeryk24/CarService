import React, {useEffect} from 'react';
import { View } from 'react-native';
import {Text} from 'react-native-elements';
import OrderFasade from '../fasade/orderFasade';

const Activities = ({route}) => {
  const { id } = route.params;
  /* let fasade = new OrderFasade();
  useEffect(() => {
    fasade.GetOrders.then(data => console.log('done'));
  }, []); */
  return (
    <View style={{flex: 1, alignItems: 'center', justifyContent: 'center'}}>
      <Text>{id}</Text>
    </View>
  );
};

export default Activities;
