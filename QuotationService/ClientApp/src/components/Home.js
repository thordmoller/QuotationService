import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hej!</h1>
        <p>Detta föreställer en väldigt simpel startsida till en städfirma. Klicka på "Offert" i menyn för att testa offert-uträknar-komponenten!</p>
        <p>Jag har använt en MySql server med Mysql workbench för detta projekt. Så det är bara att ändra "DefaultConnection" i appsettings.json så den ansluter till din databas och sedan köra kommandot "dotnet ef database update" i package manager console i visual studio.
          Sedan är det bara att testa! Databasen seedar sig själv</p>
        </div>
    );
  }
}
