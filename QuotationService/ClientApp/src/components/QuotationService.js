import React, { Component } from 'react';
import styles from './QuotationService.module.css';

export class QuotationService extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cities: [],
      selectedCity: 0,
      loadingCities: true,
      services: [],
      loadingServices: false,
    };
  }

  async componentDidMount() {
    await this.fetchCities();
  }

  fetchCities = async () => {
    try {
      const response = await fetch('cities/names');
      if (!response.ok) {
        throw new Error('Failed to fetch cities data');
      }
      const data = await response.json();
      this.setState({ cities: data, loadingCities: false });

      //välj första staden i listan när städerna laddas
      if (data.length > 0) {
        const selectedCity = data[0].id;
        this.setState({selectedCity: selectedCity});
        await this.handleCityChange({ target: { value: selectedCity } });
      }
    } catch (error) {
      console.error('Error fetching cities data:', error);
      this.setState({ loadingCities: false });
    }
  };

  fetchServices = async (cityId) => {
    try {
      const response = await fetch(`cities/${cityId}/services`);
      if (!response.ok) {
        throw new Error('Failed to fetch optional services data');
      }
      const data = await response.json();
      this.setState({ services: data, loadingServices: false });
    } catch (error) {
      console.error('Error fetching optional services data:', error);
      this.setState({ loadingServices: false });
    }
  };

  handleCityChange = async (e) => {
    const selectedCity = e.target.value;
    this.setState({ selectedCity, loadingServices: true });
    await this.fetchServices(selectedCity);
  };

  render() {
    const { cities, services, loadingServices } = this.state;

    return (
      <div className={styles.container}>
        <h1>Beräkna Offert</h1>
        <div className="p-8">
          <label htmlFor="city" className="mt-4">
            Stad:
          </label>
          <select id="city" onChange={this.handleCityChange} className="form-select px-2 py-2">
            {cities.map((city) => (
              <option key={city.id} value={city.id}>
                {city.name}
              </option>
            ))}
          </select>
          <label htmlFor="square-meters" className="mt-4">
            Kvadratmeter:
          </label>
          <input type="number" id="square-meters" className="form-control p-2" min="0" />
          <label htmlFor="optional-services" className="font-bold mt-4">
            Övriga tjänster:
          </label>
          <div className="mt-2">
            {loadingServices ? (
              <p>Loading optional services...</p>
            ) : (
              services.map((service) => (
                <div key={service.id} className="form-check">
                  <input type="checkbox" id={service.id} name={service.name} className="form-check-input" />
                  <label htmlFor={`service-${service.id}`} className="form-check-label">
                    {service.name}: {service.price} kr
                  </label>
                </div>
              ))
            )}
          </div>
          <div className="quote-result mt-4" id="quote-result">
            Pris: <span id="total-price" className="font-bold">0 kr</span>
          </div>
        </div>
      </div>
    );
  }
}
