import React, {useState, useContext} from 'react';
import {View} from 'react-native';
import {Button, Dialog, Portal, RadioButton, Text} from 'react-native-paper';
import {DialogContext} from './ActivityAccordion';
import ActivityFasade from '../fasade/ActivityFasade';

const ChooseStateDialog = ({setActivityState, activityData}) => {
  const {dialogVisible, setDialogVisible} = useContext(DialogContext);
  const [stateValue, setStateValue] = useState(2);
  const fasade = new ActivityFasade();
  return (
    <View style={{position: 'absolute'}}>
      <Portal>
        <Dialog
          style={{backgroundColor: '#333333'}}
          visible={dialogVisible}
          onDismiss={() => setDialogVisible(false)}>
          <Dialog.Title style={{color: '#fff'}}>Vyberte stav</Dialog.Title>
          <Dialog.Content>
            <RadioButton.Group
              onValueChange={newValue => setStateValue(newValue)}
              value={stateValue}>
              <View style={{flexDirection: 'row'}}>
                <RadioButton color="#FF8C00" uncheckedColor='#fff' value={0} />
                <Text style={{position: 'relative', top: 10, color: '#fff'}}>
                  Hotovo
                </Text>
              </View>

              <View style={{flexDirection: 'row'}}>
                <RadioButton color="#FF8C00" uncheckedColor='#fff' value={1} />
                <Text style={{position: 'relative', top: 10, color: '#fff'}}>
                  Probíhá
                </Text>
              </View>

              <View style={{flexDirection: 'row'}}>
                <RadioButton color="#FF8C00" uncheckedColor='#fff' value={2} />
                <Text style={{position: 'relative', top: 10, color: '#fff'}}>
                  Čeká
                </Text>
              </View>
            </RadioButton.Group>
          </Dialog.Content>
          <Dialog.Actions>
            <Button
              labelStyle={{color: '#FF8C00', fontSize: 18}}
              onPress={() => {
                setActivityState(stateValue);
                setDialogVisible(false);
                fasade.UpdateActivity({...activityData, state: stateValue});
              }}>
              Hotovo
            </Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default ChooseStateDialog;
