import React, {Component} from 'react';
import './App.css';
import axios from 'axios'
import { Header, Icon, List } from 'semantic-ui-react'

class App extends Component {

  state = {
    values:[]
  }
  componentDidMount(){
    axios.get("http://localhost:5000/api/WeatherForecast")
          .then((response) =>
          {
              this.setState({
                values : response.data
              })
          })  
  }

  render()
  {
    return (
      <div>    
         <Header as='h2'>
          <Icon name='settings' />
          <Header.Content>
            Reactivities
            <Header.Subheader>Manage your preferences</Header.Subheader>
          </Header.Content>
        </Header>
        <List link>         
          {this.state.values.map((value:any) =>(
            <List.Item as='a' key={value.id}>{value.id + " " +value.foreCast}</List.Item>
          ))}        
        </List>      
      </div>
    );
  }
 
}
// function App() {
//   return (
//     <div className="App">
//       <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.tsx</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Learn React
//         </a>
//       </header>
//     </div>
//   );
// }

export default App;
