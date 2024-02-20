import React, { Component, useEffect, useState } from 'react'
import styles from './QuotationService.module.css';


export class QuotationService extends Component {
    constructor(props) {
        super(props);
        this.state = {
          cities: [],
          selectedCity: 0,
          services: [],
          loading: true,
        };
      }
    
      componentDidMount() {
        this.fetchCities();
      }
    
      fetchCities = async () => {
        try {
          const response = await fetch('cities/names');
          if (!response.ok) {
            throw new Error('Failed to fetch data');
          }
          const data = await response.json();
          this.setState({ cities: data, loading: false });
        } catch (error) {
          console.error('Error fetching data:', error);
          this.setState({ loading: false });
        }
      };

      fetchServices = async (cityId) => {
        try {
          const response = await fetch(`cities/${cityId}/services`);
          if (!response.ok) {
            throw new Error('Failed to fetch services');
          }
          const _services = await response.json();
          this.setState({ services: _services });
        } catch (error) {
          console.error('Error fetching services:', error);
        }
      };

      handleCityChange = async (e) => {
        const _selectedCity = e.target.value;
        this.setState({ selectedCity: _selectedCity });
        console.log(_selectedCity);

        await this.fetchServices(_selectedCity);

        console.log(this.state.services[0].name)

      };

  render() {

    const { cities, services, selectedCity, loading } = this.state;
    
    
    return (
        
<div className={styles.container}>


    <h1>Beräkna Offert</h1>

  <div className="p-8">
      <label htmlFor="stad" className="mt-4">Stad:</label>
      <select id="city" onChange={this.handleCityChange} className="form-select px-2 py-2 ">

        {cities.map((city) => (
            <option key={city.id} value={city.id}>
                {city.name}
            </option>
        ))}
      </select>

      <label htmlFor="square-meters" className="mt-4">Kvadratmeter:</label>
      <input type="number" id="square-meters" className="form-control p-2" min="0" />

      <label htmlFor="optional-services" className="font-bold mt-4">Övriga tjänster:</label>
      
      <div className="mt-2">
        <div className="form-check">
        {services.length > 0 && services.map((service) => (
            <input type="checkbox" key={service.id} id={service.id} name={service.name} className="form-check-input" />
        ))}
      </div>
      </div>

    <div className="quote-result mt-4" id="quote-result">
      Pris: <span id="total-price" className="font-bold">0 kr</span>
    </div>
  </div>
</div>

    )
    
  }
}
