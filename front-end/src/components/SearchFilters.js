import { useState } from "react";
import { Flex, Box, Select, useColorModeValue, Button } from "@chakra-ui/react";
import { useDispatch } from "react-redux";

import { filterData, getFilterValues } from "../utils/filterData";
import { getSearchValue } from "../redux/search";
const SearchFilters = () => {
  const [filters] = useState(filterData);
  const [searchTerm, setSearchTerm] = useState({});

  const dispatch = useDispatch();

  const searchHandler = e => {
    e.preventDefault();
    dispatch(getSearchValue(searchTerm));
  };

  const searchProperties = filterValues => {
    const values = getFilterValues(filterValues);

    values.forEach(item => {
      if (item.value && filterValues?.[item.name]) {
        setSearchTerm(prevState => ({ ...prevState, [item.name]: item.value }));
      }
    });
  };

  return (
    <Flex
      bg={useColorModeValue("gray.100", "gray.900")}
      p='4'
      justifyContent='center'
      flexWrap='wrap'
    >
      {filters?.map(filter => (
        <Box key={filter.queryName}>
          <Select
            onChange={e =>
              searchProperties({ [filter.queryName]: e.target.value })
            }
            placeholder={filter.placeholder}
            w='fit-content'
            p='2'
          >
            {filter?.items?.map(item => (
              <option value={item.value} key={item.value}>
                {item.name}
              </option>
            ))}
          </Select>
        </Box>
      ))}
      <Button onClick={searchHandler}>search</Button>
    </Flex>
  );
};
export default SearchFilters;
