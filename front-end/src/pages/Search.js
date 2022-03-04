import { useEffect, useState } from "react";
import {
  Flex,
  Box,
  Text,
  Icon,
  useColorModeValue,
  Image,
} from "@chakra-ui/react";
import { BsFilter } from "react-icons/bs";

import SearchFilters from "../components/SearchFilters";

import noresult from "../assets/images/noresult.svg";
import { useDispatch } from "react-redux";

const Search = () => {
  const [searchFilters, setSearchFilters] = useState(false);
  const properties = [];
  useEffect(() => {});
  return (
    <Box>
      <Flex
        onClick={() => setSearchFilters(!searchFilters)}
        cursor='pointer'
        bg={useColorModeValue("gray.100", "gray.900")}
        borderBottom='1px'
        borderColor='gray.200'
        mt='2'
        p='2'
        fontWeight='black'
        fontSize='lg'
        justifyContent='center'
        alignItems='center'
      >
        <Text>Search Property By Filters</Text>
        <Icon pl='2' w='7' as={BsFilter} />
      </Flex>
      {searchFilters && <SearchFilters />}
      <Text fontSize='2xl' p='4' fontWeight='bold'>
        Properties
        {/* {router.query.purpose} */}
      </Text>
      {/* TDD: Map for propertyList */}
      {properties.length === 0 && (
        <Flex
          justifyContent='center'
          alignItems='center'
          flexDir='column'
          marginTop='5'
          marginBottom='5'
        >
          <Image src={noresult} />
          <Text fontSize='xl' marginTop='3'>
            No Result Found.
          </Text>
        </Flex>
      )}
    </Box>
  );
};

export default Search;
