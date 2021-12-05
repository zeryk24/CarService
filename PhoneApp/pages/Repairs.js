// Author: Michal Zavadil (xzavad18)
import React, {useEffect, useState} from 'react';
import { View, Text} from 'react-native';
import RepairFasade from '../fasade/RepairFasade';
import {List} from 'react-native-paper';
import RepairStateIcon from '../components/RepairStateIcon';

const Repairs = ({navigation}) => {
  const [ordersList, setOrdersList] = useState([]);
  const fasade = new RepairFasade();
  useEffect(() => {
    fasade.GetRepairs().then(data => {
      setOrdersList(data)});
  }, []);
  return (
    <View style={{flex: 1, backgroundColor: '#4c4c4c'}}>
      {ordersList.map((item) => (
        <List.Item
          key={item.id}
          title={item.description}
          right={() => <RepairStateIcon state={item.state}/>}
          description={'SPZ: ' + item.order.carSpz}
          onPress={() => navigation.navigate('Activities', {...item})}
          style={{backgroundColor: '#333333'}}
          titleStyle={{color: '#E5E5E5'}}
          descriptionStyle={{color: '#CCCCCC'}}
        />
      ))}
      
    </View>
  );
};

export default Repairs;
