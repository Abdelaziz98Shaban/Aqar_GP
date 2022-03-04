// Sample card from Airbnb
import React,{useEffect} from 'react';
import {Box, Image, Badge } from '@chakra-ui/react';
import {StarIcon} from '@chakra-ui/icons';
import {Link} from 'react-router-dom';
import { useDispatch, useSelector } from "react-redux";
import { loadProperties } from '../redux/properties';

function Property() {
    const card = useSelector(state=>state.entities.properties.list)
    // const {list} = useSelector(state=>state.entities.properties);

    console.log(card[0]);
    const dispatch = useDispatch();
  useEffect(() => {
    dispatch(loadProperties());
  }, [dispatch]);
    const property =  {
      imageUrl: "data:image/png;base64, "+card[0].image,
      imageAlt: 'Rear view of modern home with pool',
      beds: 3,
      baths: 2,
      title: card[0].title,
      formattedPrice: card[0].price,
      reviewCount: 34,
      rating: 4,
    }
  
    return (
        <>
        <h1>Real State product List</h1>
      <Box maxW='sm' borderWidth='1px' borderRadius='lg' overflow='hidden' m={10}>
          <Link to="/">
        <Image src={property.imageUrl} alt={property.imageAlt} />
        </Link>
        <Box p='6'>
          <Box display='flex' alignItems='baseline'>
            <Badge borderRadius='full' px='2' colorScheme='teal'>
              New
            </Badge>
            <Box
              color='gray.500'
              fontWeight='semibold'
              letterSpacing='wide'
              fontSize='xs'
              textTransform='uppercase'
              ml='2'
            >
              {property.beds} beds &bull; {property.baths} baths
            </Box>
          </Box>
  
          <Box
            mt='1'
            fontWeight='semibold'
            as='h4'
            lineHeight='tight'
            isTruncated
          >
            {property.title}
          </Box>
  
          <Box>
            {property.formattedPrice}
            <Box as='span' color='gray.600' fontSize='sm'>
              / wk
            </Box>
          </Box>
  
          <Box display='flex' mt='2' alignItems='center'>
            {Array(5)
              .fill('')
              .map((_, i) => (
                <StarIcon
                  key={i}
                  color={i < property.rating ? 'teal.500' : 'gray.300'}
                />
              ))}
            <Box as='span' ml='2' color='gray.600' fontSize='sm'>
              {property.reviewCount} reviews
            </Box>
          </Box>
        </Box>
      </Box>
      </>
    )
  }
  
export default Property;
