import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import './custom.css'
import Home from './sites/Home';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { orange, grey } from '@mui/material/colors';
const theme = createTheme({
  palette: {
    mode: "dark",
    primary: orange,
    secondary: grey
  },
});


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <ThemeProvider theme={theme}>
        <Layout>
          <Route exact path='/' component={Home} />
        </Layout>
      </ThemeProvider>
    );
  }
}
