// Author: Michal Zavadil (xzavad18)
import React, {useEffect} from 'react';

import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';

import Repairs from './pages/Repairs';
import Activities from './pages/Activities';

const Stack = createNativeStackNavigator();

const App = () => {
  return (
      <NavigationContainer>
        <Stack.Navigator
          screenOptions={{
            headerStyle: {
              backgroundColor: '#FF8C00',
            },
            headerTintColor: '#000',
            headerTitleStyle: {
              fontWeight: 'bold',

            },
          }}>
          <Stack.Screen name="Opravy" component={Repairs} />
          <Stack.Screen
            name="Activities"
            component={Activities}
            options={({route}) => ({title: route.params.description + ': ' + route.params.order.carSpz})}
          />
        </Stack.Navigator>
      </NavigationContainer>
  );
};

export default App;