import React, {useEffect, useState} from 'react';
import { Button, View, Text } from 'react-native';
// import {Text, Button} from 'react-native-elements';
import OrderFasade from '../fasade/orderFasade';

const Orders = ({navigation}) => {
  const [ordersList, setOrdersList] = useState([]);
  let fasade = new OrderFasade();
  useEffect(() => {
    console.log('reee');
    fasade.GetOrders().then(data => setOrdersList(data));
  }, []);
  return (
    <View>
        {ordersList.map((item, index) => (
          <Button
          title={item.description}
          onPress={() => navigation.navigate('Activities', {id: 'prvni'})}
        />
        ))}
    </View>
  );
};

export default Orders;
