import React, { useEffect, useState } from 'react';

const CityList = () => {
    const [cities, setCities] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchCities = async () => {
            try {
                const response = await fetch('cities');
                if (!response.ok) {
                    throw new Error('Failed to fetch data');
                }
                const data = await response.json();
                setCities(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching data:', error);
                setLoading(false);
            }
        };

        fetchCities();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>City List</h1>
            <ul>
                {cities.map(city => (
                    <li key={city.name}>
                        <strong>{city.name}</strong> (Rate: {city.rate})
                        <ul>
                            {city.services.map(service => (
                                <li key={service.name}>
                                    {service.name}: {service.price} kr
                                </li>
                            ))}
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CityList;
