import React, { useEffect } from "react";

import { Flex, Box } from "@chakra-ui/react";

import { useDispatch, useSelector } from "react-redux";

import Banner from "../components/Banner";
import Property from "../components/Property";

import {
  loadpropertiesForSale,
  loadpropertiesForRent,
} from "../redux/properties";
import NoResult from "../components/common/NoResult";

const Properties = () => {
  const { propertiesForRent, propertiesForSale } = useSelector(
    state => state.entities.properties
  );
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(loadpropertiesForRent());
    dispatch(loadpropertiesForSale());
  }, [dispatch]);
  return (
    <Box>
      <Banner
        purpose='RENT A HOME'
        title1='Rental Homes for'
        title2='Everyone'
        desc1=' Explore from Apartments, builder floors, villas'
        desc2='and more'
        buttonText='Explore Renting'
        linkName='/search?purpose=for-rent'
        imageUrl='https://bayut-production.s3.eu-central-1.amazonaws.com/image/145426814/33973352624c48628e41f2ec460faba4'
      />
      <Flex flexWrap='wrap' justifyContent='center'>
        {propertiesForSale.map(property => (
          <Property property={property} key={property.id} />
        ))}
      </Flex>
      <Banner
        purpose='BUY A HOME'
        title1=' Find, Buy & Own Your'
        title2='Dream Home'
        desc1=' Explore from Apartments, land, builder floors,'
        desc2=' villas and more'
        buttonText='Explore Buying'
        linkName='/search?purpose=for-sale'
        imageUrl='https://bayut-production.s3.eu-central-1.amazonaws.com/image/110993385/6a070e8e1bae4f7d8c1429bc303d2008'
      />
      <Flex flexWrap='wrap' justifyContent='center'>
        {propertiesForRent.map(property => (
          <Property property={property} key={property.id} />
        ))}
      </Flex>
      <NoResult count={propertiesForRent.length} />
    </Box>
  );
};

export default Properties;
