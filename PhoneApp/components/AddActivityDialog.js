// Author: Michal Zavadil (xzavad18)
import React, {useState, useContext, useEffect} from 'react';
import {View, Text} from 'react-native';
import {Button, Dialog, Portal, TextInput} from 'react-native-paper';
import {DialogContext} from './ActivityAccordion';
import ActivityFasade from '../fasade/ActivityFasade';

const AddActivityDialog = ({
  setActivities,
  dialogVisible,
  setDialogVisible,
  repairId,
}) => {
  useEffect(() => {
    setValues({name: '', description: ''});
  }, [dialogVisible]);
  const [values, setValues] = useState({name: '', description: ''});
  const fasade = new ActivityFasade();
  return (
    <View style={{position: 'absolute'}}>
      <Portal>
        <Dialog
          style={{backgroundColor: '#333333'}}
          visible={dialogVisible}
          onDismiss={() => setDialogVisible(false)}>
          <Dialog.Title style={{color: '#fff'}}>Přidat aktivitu</Dialog.Title>
          <Dialog.Content>
            <TextInput
              theme={{colors: {primary: '#000'}}}
              label="Název"
              value={values.name}
              onChangeText={text => setValues({...values, name: text})}
            />
            <TextInput
              theme={{colors: {primary: '#000'}}}
              label="Popis"
              value={values.description}
              onChangeText={text => setValues({...values, description: text})}
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button
              labelStyle={{color: '#FF8C00', fontSize: 18}}
              onPress={() => {
                setActivities(current => [
                  ...current,
                  {
                    name: values.name,
                    description: values.description,
                    state: 2,
                  },
                ]);
                setDialogVisible(false);
                fasade
                  .CreateActivity({...values, state: 2, repairId: repairId})
                  .then(response => console.log(response));
              }}>
              Hotovo
            </Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default AddActivityDialog;
