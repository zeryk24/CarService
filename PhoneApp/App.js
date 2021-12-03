import React, {useEffect} from 'react';
import {Button, ThemeProvider} from 'react-native-elements';
import {View} from 'react-native';
import Header from './components/AppHeader';

import {NavigationContainer} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';

import Orders from './pages/Orders';
import Activities from './pages/Activities';

const theme = {
  colors: {
    //primary: '#FF8C00',
    primary: '#2B2B2B',
    //primary: '#ffffff',
  },
};

const Stack = createNativeStackNavigator();

const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen name="Orders" component={Orders} />
        <Stack.Screen name="Activities" component={Activities} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;

/* <ThemeProvider theme={theme}>
        <Header />
        <Button title="Hey!" />
        <NavigationContainer>
          <Stack.Navigator>
            <Stack.Screen name="Orders" component={Orders} />
            <Stack.Screen name="Activities" component={Activities} />
          </Stack.Navigator>
        </NavigationContainer>
    </ThemeProvider> */
